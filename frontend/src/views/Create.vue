<template>
  <div class="boxCustom">
    <h1>New Vehicle Page</h1>
    <v-form ref="form" v-model="valid" lazy-validation>
      <v-text-field v-model="plate" label="Plate" required></v-text-field>
      <v-text-field v-model="nickname" label="Nickname" required></v-text-field>
      <v-text-field v-model="brand" label="Brand" required></v-text-field>
      <v-text-field v-model="model" label="Model" required></v-text-field>
      <v-text-field
        v-model="modelYear"
        label="Model Year"
        required
      ></v-text-field>
      <v-text-field v-model="type" label="Type" required></v-text-field>
      <v-text-field v-model="color" label="Color" required></v-text-field>
      <v-switch v-model="state" label="State"></v-switch>

      <v-btn color="warning" @click="createVehicle">
        Add Vehicle
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
    createVehicle() {
      let newVehicle = {
        plate: this.plate,
        nickname: this.nickname,
        brand: this.brand,
        model: this.model,
        modelYear: parseInt(this.modelYear),
        type: this.type,
        color: this.color,
        state: this.state,
      };
      axios
        .post(`http://localhost:5000/api/vehicle`, newVehicle)
        .then((response) => {
          console.log(response);
          this.$router.push("/");
        });
    },
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
