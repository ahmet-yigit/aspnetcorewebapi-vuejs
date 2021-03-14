<template>
  <div class="boxCustom">
    <h1>Edit Vehicle Page</h1>
    <v-form ref="form" v-model="valid" lazy-validation>
      <v-text-field
        v-model="dataDetails.id"
        :counter="10"
        label="Id"
        required
        disabled
      ></v-text-field>
      <v-text-field
        v-model="dataDetails.plate"
        label="Plate"
        required
      ></v-text-field>
      <v-text-field
        v-model="dataDetails.Nickname"
        label="Nickname"
        required
      ></v-text-field>
      <v-text-field
        v-model="dataDetails.brand"
        label="Brand"
        required
      ></v-text-field>
      <v-text-field
        v-model="dataDetails.model"
        label="Model"
        required
      ></v-text-field>
      <v-text-field
        v-model="dataDetails.modelYear"
        label="Model Year"
        required
      ></v-text-field>
      <v-text-field
        v-model="dataDetails.type"
        label="Type"
        required
      ></v-text-field>
      <v-text-field
        v-model="dataDetails.color"
        label="Color"
        required
      ></v-text-field>
      <v-switch v-model="dataDetails.state" label="State"></v-switch>

      <v-btn color="warning" @click="updateProduct(dataDetails.id)">
        Update
      </v-btn>
    </v-form>
  </div>
</template>

<script>
import axios from "axios";
export default {
  props: ["Details"],
  data() {
    return {
      dataDetails: [],
      plate: "",
      nickname: "",
      brand: "",
      model: "",
      modelYear: "",
      type: "",
      color: "",
      state: "",
    };
  },
  methods: {
    getDetails() {
      axios
        .get(`http://localhost:5000/api/vehicle/${this.Details.id}`)
        .then((response) => {
          this.dataDetails = response.data;
          console.log(this.dataDetails);
        });
    },
    updateProduct(id) {
      let upPro = {
        plate: this.dataDetails.plate,
        nickname: this.dataDetails.nickname,
        brand: this.dataDetails.brand,
        model: this.dataDetails.model,
        modelYear: this.dataDetails.modelYear,
        type: this.dataDetails.type,
        color: this.dataDetails.color,
        state: this.dataDetails.state,
      };
      axios
        .put(`http://localhost:5000/api/vehicle/${id}`, upPro)
        .then((response) => {
          console.log(response);
          this.$router.push("/");
        });
    },
  },
  created() {
    this.getDetails();
  },
};
</script>

<style scoped>
.boxCustom {
  text-align: center;
  position: relative;
  margin: 0 auto;
  margin-top: 50px;
  width: 600px;
}
</style>
