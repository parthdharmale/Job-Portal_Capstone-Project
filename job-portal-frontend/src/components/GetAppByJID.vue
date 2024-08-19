<template>
  <div>
    <h1>Job Applications By Job ID</h1>
    
    <div class="form-group">
      <label for="jobId">Enter Job ID: </label>
      <input v-model="jobId" id="jobId" type="text" placeholder="Enter Job ID" />
      <button @click="fetchApplications" class="submit-button">Fetch Applications</button>
    </div>

    <div v-if="applications.length">
      <table>
        <thead>
          <tr>
            <th>Application ID</th>
            <th>Candidate ID</th>
            <th>Resume</th>
            <th>Status</th>
            <th>Date Of Application</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="application in applications" :key="application.id">
            <td>{{ application.applicationID }}</td>
            <td>{{ application.cid }}</td>
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
  data() {
    return {
      jobId: '',
      applications: [],
      errorMessage: ''
    };
  },
  methods: {
    async fetchApplications() {
      if (!this.jobId) {
        this.errorMessage = 'Job ID is required!';
        return;
      }

      this.errorMessage = '';
      try {
        const response = await axios.get(`https://localhost:7077/api/Application/GetApplicationByJobId/${this.jobId}`);
        this.applications = response.data;
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
