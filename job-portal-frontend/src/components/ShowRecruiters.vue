<template>
  <div>
    <h1>Recruiters List</h1>
    <table v-if="recruiters.length">
      <thead>
        <tr>
          <th>Recruiter ID</th>
          <th>Name</th>
          <th>Email</th>
          <th>City Name</th>
          <th>Phone</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="recruiter in recruiters" :key="recruiter.recruiterID">
          <td>{{ recruiter.rid }}</td>
          <td>{{ recruiter.name }}</td>
          <td>{{ recruiter.email }}</td>
          <td>{{ getCityName(recruiter.cityID) }}</td>
          <td>{{ recruiter.contact }}</td>
        </tr>
      </tbody>
    </table>
    <p v-else>No recruiters found.</p>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'ShowRecruiters',
  data() {
    return {
      recruiters: [],
      cities: [],
    };
  },
  created() {
    this.fetchRecruiters();
  },
  methods: {
    fetchRecruiters() {
      axios.get("https://localhost:7077/api/Recruiter/GetAllRecruiters")
        .then(response => {
          this.recruiters = response.data;
        })
        .catch(error => {
          console.error("There was an error fetching the recruiters!", error);
        });
        this.getCities();
    },
    getCities() {
      axios.get("https://localhost:7077/api/City/GetAllCities")
        .then(response => {
          this.cities = response.data;
          console.log(response);
        })
        .catch(error => {
          console.log(error);
        });
    },
    getCityName(cityID) {
      const city = this.cities.find(city => city.cityID === cityID);
      console.log("This is city id" +cityID);
      return city ? city.cityName : 'Unknown City';
    },
  }
};
</script>

<style scoped>
table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 20px;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: left;
}

th {
  background-color: #f4f4f4;
}
</style>
