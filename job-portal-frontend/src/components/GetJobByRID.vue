<template>
  <div>
    <h1>Open Jobs By Recruiter ID</h1>
    
    <div class="form-group">
      <label for="rid">Enter Recruiter ID: </label>
      <input v-model="rid" id="rid" type="text" placeholder="Enter Recruiter ID" />
      <button @click="fetchJobs" class="submit-button">Fetch Jobs Posted by the Recruiter</button>
    </div>

    <div v-if="jobs.length">
      <table>
        <thead>
          <tr>
            <th>Job ID</th>
            <th>Recruiter ID</th>
            <!-- <th>City ID</th> -->
            <th>Location</th>
            <th>Description</th>
            <th>Required Skills</th>
            <th>Recruiter Name</th>
            <th>Job Post Date</th>
            <th>Job Expiry Date</th>
            <th>Mode Of Work</th>
            

          </tr>
        </thead>
        <tbody>
          <tr v-for="job in jobs" :key="job.id">
            <td>{{ job.jobID }}</td>
            <td>{{ job.rid }}</td>
            <!-- <td>{{ job.cityID }}</td> -->
            <td>{{ job.location }}</td>
            <td>{{ job.description }}</td>
            <td>{{ job.skills }}</td>
            <td>{{ job.recruiterName }}</td>
            <td>{{ job.jobPostDate }}</td>
            <td>{{ job.jobExpireDate }}</td>
            <td>{{ job.modeOfWork }}</td>
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
      rid: '',
      jobs: [],
      errorMessage: ''
    };
  },
  methods: {
    async fetchJobs() {
      if (!this.rid) {
        this.errorMessage = 'Recruiter ID is required!';
        return;
      }
        console.log("Button Clicked");
      this.errorMessage = '';
      try {
        const response = await axios.get(`https://localhost:7077/api/Job/GetJobByRecruiterID/${this.rid}`);
        this.jobs = response.data;
        console.log(this.jobs);
      } catch (error) {
        this.errorMessage = 'Failed to fetch jobs. Please try again later.';
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
