<template>
  <div class="boxCustom">
    <h1>Vehicle List Pages</h1>
    <br />
    <div class="search-wrapper">
      <v-text-field v-model="search" label="Search"></v-text-field>
    </div>
    <br />
    <v-simple-table>
      <template v-slot:default>
        <thead>
          <tr>
            <th class="text-center">Id</th>
            <th class="text-center">Plate</th>
            <th class="text-center">Nickname</th>
            <th class="text-center">Brand</th>
            <th class="text-center">Model</th>
            <th class="text-center">Model Year</th>
            <th class="text-center">Type</th>
            <th class="text-center">Color</th>
            <th class="text-center">State</th>
            <th class="text-center">Edit</th>
            <th class="text-center">Delete</th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="(item, index) in data"
            :key="index"
            :class="item.searchActive === true ? 'search-active' : ''"
          >
            <td>{{ item.id }}</td>
            <td>{{ item.plate }}</td>
            <td>{{ item.nickname }}</td>
            <td>{{ item.brand }}</td>
            <td>{{ item.model }}</td>
            <td>{{ item.modelYear }}</td>
            <td>{{ item.type }}</td>
            <td>{{ item.color }}</td>
            <td>{{ item.state === true ? "ACTIVE" : "PASSIVE" }}</td>
            <td>
              <v-btn color="info" @click="Details(item)">
                Edit
              </v-btn>
            </td>
            <td>
              <v-btn color="success" @click="Delete(item)">
                Delete
              </v-btn>
            </td>
          </tr>
        </tbody>
      </template>
    </v-simple-table>

    <br />
    <v-btn color="primary" to="/Create">
      Add Vehicle
    </v-btn>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      search: "",
      data: [],
    };
  },
  watch: {
    search() {
      this.getAllProduct();
    },
  },
  mounted() {
    axios.get(this.url).then((response) => {
      this.data = response.data;
    });
  },
  methods: {
    activeClass({ row }) {
      if (row.searchActive == true) {
        return "search-active";
      }
    },
    getAllProduct() {
      axios.get(`http://localhost:5000/api/vehicle/`).then((response) => {
        this.data = response.data;
        this.data.forEach((key) => (key.searchActive = false));
        this.data
          .filter(
            (x) =>
              this.search &&
              x.nickname.toLowerCase().includes(this.search.toLowerCase())
          )
          .forEach((key) => (key.searchActive = true));
      });
    },
    Details(row) {
      this.$router.push({
        name: "Detail",
        params: { Details: row },
      });
    },
    Delete(row) {
      axios
        .delete(`http://localhost:5000/api/vehicle/${row.id}`)
        .then((response) => {
          console.log(response);
          this.$router.go(0);
        });
    },
  },
  created() {
    this.getAllProduct();
  },
  computed: {
    filteredList() {
      return this.data.filter((post) => {
        return post.title.toLowerCase().includes(this.search.toLowerCase());
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
  width: 90%;
}

.search-active {
  background-color: red;
}
</style>
