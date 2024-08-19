<template>
  <div>
    <h1>Candidates List</h1>
    <table v-if="candidates.length">
      <thead>
        <tr>
          <th>Candidate ID</th>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Email</th>
          <th>Date Of Birth</th>
          <th>Address</th>
          <th>Contact</th>
          <th>City</th>
          <th>Education 1</th>
          <th>Education 1 Result</th>
          <th>Education 2</th>
          <th>Education 2 Result</th>
          <th>Education 3</th>
          <th>Education 3 Result</th>

        </tr>
      </thead>
      <tbody>
        <tr v-for="candidate in candidates" :key="candidate.candidateID">
          <td>{{ candidate.cid }}</td>
          <td>{{ candidate.firstName }}</td>
          <td>{{ candidate.lastName }}</td>
          <td>{{ candidate.email }}</td>
          <td>{{ candidate.dob }}</td>
          <td>{{ candidate.address }}</td>
          <td>{{ candidate.contact }}</td>
          <!-- <td>{{ candidate.cityID }}</td> -->
          <td>{{ getCityName(candidate.cityID) }}</td>

          <td>{{ candidate.education1 }}</td>
          <td>{{ candidate.educationResult1 }}</td>
          <td>{{ candidate.education2 }}</td>
          <td>{{ candidate.educationResult2 }}</td>
          <td>{{ candidate.education3 }}</td>
          <td>{{ candidate.educationResult3 }}</td>
          <!-- Add more data fields as needed -->
        </tr>
      </tbody>
    </table>
    <p v-else>No candidates found.</p>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'ShowCandidates',
  data() {
    return {
      candidates: [],
      cities: []

    };
  },
  created() {
    this.fetchCandidates();
  },
  methods: {
    fetchCandidates() {
      axios.get("https://localhost:7077/api/Candidate/GetAllCandidates")
        .then(response => {
          this.candidates = response.data;
        })
        .catch(error => {
          console.error("There was an error fetching the candidates!", error);
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
