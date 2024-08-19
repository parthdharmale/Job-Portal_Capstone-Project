<template>
  <div>
    <h1>Post a Job</h1>
    <form @submit.prevent="insertDetails" class="form">
      <div class="form-group">
        <label for="rid">Enter Recruiter ID:</label>
        <input type="text" id="rid" v-model="formData.rid" required />
      </div>
      <div class="form-group">
        <label for="recruiterName">Enter Recruiter Name:</label>
        <input type="text" id="recruiterName" v-model="formData.recruiterName" required />
      </div>
      <div class="form-group">
        <label for="recruiterContact">Enter Recruiter Contact No.:</label>
        <input type="text" id="recruiterContact" v-model="formData.recruiterContact" required />
      </div>
      <div class="form-group">
        <label for="recruiterEmail">Enter Recruiter Email:</label>
        <input type="email" id="recruiterEmail" v-model="formData.recruiterEmail" required />
      </div>
      <div class="form-group">
        <label for="cityID">Select City:</label>
        <select id="cityID" v-model="formData.cityID" required>
          <option value="" disabled>Select a city</option>
          <option v-for="city in cities" :key="city.id" :value="city.cityID">
            {{ city.cityName }}
          </option>
        </select>
      </div>
      <div class="form-group">
        <label for="description">Enter Job Description:</label>
        <input type="text" id="description" v-model="formData.description" required />
      </div>
      <div class="form-group">
        <label for="location">Enter Job Location:</label>
        <input type="text" id="location" v-model="formData.location" required />
      </div>
      <div class="form-group">
        <label for="skills">Enter Required Skills:</label>
        <input type="text" id="skills" v-model="formData.skills" required />
      </div>
      <div class="form-group">
        <label for="jobExpireDate">Enter Job Expiry Date:</label>
        <input type="date" id="jobExpireDate" v-model="formData.jobExpireDate" required />
      </div>
      <div class="form-group">
        <label for="modeOfWork">Enter Mode Of Work For the Job:</label>
        <input type="text" id="modeOfWork" v-model="formData.modeOfWork" required />
      </div>
      <div>
        <button type="submit" class="submit-button">Post the Job</button>
      </div>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'AddJob',
  data() {
    return {
      formData: {
        rid: '',
        cityID: '', 
        location: '',
        description: '',
        skills: '',
        recruiterName: '',
        recruiterContact: '',
        recruiterEmail: '',
        jobPostDate: new Date().toISOString().split('T')[0],
        jobExpireDate: '',
        modeOfWork: '',
      },
      cities: []
    };
  },
  created() {
    this.fetchCities(); 
  },
  methods: {
    async fetchCities() {
      try {
        const response = await axios.get('https://localhost:7077/api/City/GetAllCities'); 
        this.cities = response.data; 
      } catch (error) {
        console.error('Error fetching cities:', error);
       
      }
    },
    insertDetails() {
      if (!this.formData.cityID) {
        alert('Please select a city');
        return;
      }

      axios.post("https://localhost:7077/api/Job/AddJob", this.formData)
        .then(response => {
          console.log(response);
          this.resetForm();
        })
        .catch(error => {
          console.error('Error:', error.response?.data || error.message);
        });
    },
    resetForm() {
      this.formData = {
        rid: '',
        cityID: '', 
        location: '',
        description: '',
        skills: '',
        recruiterName: '',
        recruiterContact: '',
        recruiterEmail: '',
        jobPostDate: new Date().toISOString().split('T')[0],
        jobExpireDate: '',
        modeOfWork: '',
      };
    }
  }
}
</script>

<style scoped>
.form {
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ddd;
  border-radius: 8px;
  background-color: #f9f9f9;
}

.form-group {
  margin-bottom: 15px;
}

label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
}

input, select {
  width: 100%;
  padding: 8px;
  border: 1px solid #ddd;
  border-radius: 4px;
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

.submit-button:hover {
  background-color: #0056b3;
}
</style>
