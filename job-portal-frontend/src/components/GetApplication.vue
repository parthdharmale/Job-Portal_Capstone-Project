<template>
  <div>
    <h1>Fetch Application Details</h1>
    <button v-if="!isClicked" @click="getApplications" class="submit-button">Click Here</button>
    <table v-if="applications.length">
      <thead>
        <tr>
          <th>Application ID</th>
          <th>Job ID</th>
          <th>Candidate ID</th>
          <th>Candidate Name</th>
          <th>Resume</th>
          <th>Skills</th>
          <th>Status</th>
          <th>Date of Application</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="application in applications" :key="application.ApplicationID">
          <td>{{ application.applicationID }}</td>
          <td>{{ application.jobID }}</td>
          <td>{{ application.cid }}</td>
          <td>{{ getCandidateName(application.cid) }}</td>
          <td>{{ application.resume }}</td>
          <td>{{ application.skills }}</td>
          <td>{{ application.status }}</td>
          <td>{{ application.dateOfApplication }}</td>
        </tr>
      </tbody>
    </table>
    <!-- <p v-else>No applications found.</p> -->
    <!-- <button @click="goBack" class="back-button">Back to Selection</button> -->
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'GetApplications',
  data() {
    return {
      applications: [],
      candidates: [],
      isClicked : false,
    };
  },
  methods: {
    getApplications() {
      axios.get("https://localhost:7077/api/Application/GetAllApplications")
        .then(response => {
          console.log(response.data);
          this.applications = response.data;
        })
        .catch(error => {
          console.log(error);
        });

      this.getCandidates();
      this.isClicked = true;
    },

    getCandidates(){
      axios.get("https://localhost:7077/api/Candidate/GetAllCandidates")
        .then(response => {
          this.candidates = response.data;
          console.log(response);
        })
        .catch(error => {
          console.log(error);
        });
    },

    getCandidateName(CID) {
      const candidate = this.candidates.find(candidate => candidate.cid === CID);
      console.log("This is Candidate id" + CID);
      return candidate ? candidate.firstName + " " + candidate.lastName : 'Unknown Candidate';
    },

    goBack() {
      this.$emit('back-to-selection');
    }
  }
}
</script>

<style scoped>
.back-button {
  margin-top: 20px;
  display: inline-block;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  background-color: #6c757d;
  color: #fff;
  cursor: pointer;
  font-size: 16px;
  flex-direction: column;
}

.back-button:hover {
  background-color: #5a6268;
}
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

.button {
  margin-top: 20px;
  margin-left: 20px;
  margin-bottom: 20px;
}
</style>
