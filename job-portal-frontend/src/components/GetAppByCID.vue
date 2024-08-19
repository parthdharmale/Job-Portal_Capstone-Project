<template>
  <div>
    <h1>Your Job Applications </h1>
    
    <div class="form-group">
      <!-- <label for="candidateId">Your Candidate ID: </label>
      <input v-model="candidateId" id="candidateId" type="text" placeholder="Enter Candidate ID" /> -->
      <button @click="fetchApplications" class="submit-button">Fetch Applications</button>
    </div>

    <div v-if="applications.length">
      <table>
        <thead>
          <tr>
            <th>Application ID</th>
            <th>Job ID</th>
            <th>Resume</th>
            <th>Status</th>
            <th>Date Of Application</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="application in applications" :key="application.id">
            <td>{{ application.applicationID }}</td>
            <td>{{ application.jobID }}</td>
            <td>{{ application.resume }}</td>
            <td>{{ application.status }}</td>
            <td>{{ application.dateOfApplication }}</td>
          </tr>
        </tbody>
      </table>
    </div>

    <div v-else-if="errorMessage">
      <p>{{ errorMessage }}</p>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  props: ['candidateID'],
  data() {
    return {
      candidateId: this.candidateID,
      applications: [],
      errorMessage: ''
    };
  },
  methods: {
    async fetchApplications() {
      if (!this.candidateId) {
        this.errorMessage = 'Candidate ID is required!';
        return;
      }

      this.errorMessage = '';
      try {
        const response = await axios.get(`https://localhost:7077/api/Application/GetApplicationByCandidateId/${this.candidateId}`);
        this.applications = response.data;
        console.log(this.applications);
      } catch (error) {
        this.errorMessage = 'Failed to fetch applications. Please try again later.';
        console.error(error);
      }
    }
  }
};
</script>

<style scoped>
/* Add your styles here */
table {
  width: 100%;
  border-collapse: collapse;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
}

th {
  background-color: #f4f4f4;
}

.submit-button {
  background-color: #007bff;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
}

.form-group {
  margin-bottom: 15px;
}
</style>
