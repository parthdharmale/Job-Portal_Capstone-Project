<template>
  <div>
    <h1>Fetch Recruiter Details</h1>
    <button @click="getRecruiters" class="submit-button">Click Here</button>
    <table v-if="recruiters.length">
      <thead>
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>City ID</th>
          <th>Email</th>
          <th>Contact</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="recruiter in recruiters" :key="recruiter.RID">
          <td>{{ recruiter.rid }}</td>
          <td>{{ recruiter.name }}</td>
          <td>{{ recruiter.cityID }}</td>
          <td>{{ recruiter.email }}</td>
          <td>{{ recruiter.contact }}</td>
        </tr>
      </tbody>
    </table>
    <!-- <p v-else>No recruiters found.</p> -->
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'GetRecruiters',
  data() {
    return {
      recruiters: []
    };
  },
  methods: {
    getRecruiters() {
      axios.get("https://localhost:7077/api/Recruiter/GetAllRecruiters")
        .then(response => {
          console.log(response.data);
          this.recruiters = response.data;
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
}
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
