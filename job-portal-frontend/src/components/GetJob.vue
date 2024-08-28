<template>
  <div>
    <h1>Fetch Job Details</h1>
    <button v-if="!isClicked" @click="getJobs" class="submit-button">Click Here To See Open Jobs</button>
    <table v-if="jobs.length">
      <thead>
        <tr>
          <th>Job ID</th>
          <th>Description</th>
          <th>City Name</th>
          <!-- <th>Recruiter ID</th> -->
          <th>Location</th>
          <th>Skills</th>
          <th>Recruiter Name</th>
          <th>Recruiter Contact</th>
          <th>Recruiter Email</th>
          <th>Mode of Work</th>
          <th v-if="isLogged!='yes' ">Actions</th> 
        </tr>
      </thead>
      <tbody>
        <tr v-for="job in jobs" :key="job.jobID">
          <td>{{ job.jobID }}</td>
          <td>{{ job.description }}</td>
          <!-- <td>{{ job.cityID }}</td> -->
          <td>{{ getCityName(job.cityID) }}</td>
          <!-- <td>{{ job.rid }}</td> -->
          <td>{{ job.location }}</td>
          <td>{{ job.skills }}</td>
          <td>{{ job.recruiterName }}</td>
          <td>{{ job.recruiterContact }}</td>
          <td>{{ job.recruiterEmail }}</td>
          <td>{{ job.modeOfWork }}</td>
          <td v-if="isLogged!='yes' ">
            <button  @click="applyForJob(job.jobID)">Apply</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from 'axios';
// import PostApplicationVue from './PostApplication.vue';

export default {
  name: 'GetJobs',
  components:
  {
    // PostApplicationVue
  },
  data() {
    return {
      jobs: [],
      cities: [],
      isClicked: false,
      isLogged: localStorage.getItem("adminLogged"),
    };
  },
  methods: {
    getJobs() {
      this.isClicked = true;
      axios.get("https://localhost:7077/api/Job/GetAllJobs")
        .then(response => {
          console.log(response.data);
          this.jobs = response.data;
        })
        .catch(error => {
          console.log(error);
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
      // console.log("This is city id" +cityID);
      const city = this.cities.find(city => city.cityID === cityID);
      console.log("This is city id" +cityID);
      return city ? city.cityName : 'Unknown City';
    },
    applyForJob(jobID) {
      this.$emit('apply-job', jobID); 
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

.submit-button {
  background-color: #007bff;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
}
</style>
