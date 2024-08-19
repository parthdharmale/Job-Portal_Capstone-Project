<template>
  <div>
    <h1>Add Recruiter Information</h1>
    <form @submit.prevent="insertDetails" class="form">
      <div class="form-group">
        <label for="name">Enter Recruiter Name:</label>
        <input type="text" id="name" v-model="formData.name" required />
      </div>
      <div class="form-group">
        <label for="cityID">Select City:</label>
        <select id="cityID" v-model="formData.cityID" @change="updateCityID" required>
          <option value="" disabled>Select a city</option>
          <option v-for="city in cities" :key="city.id" :value="city.cityID">
            {{ city.cityName }}
          </option>
        </select>
      </div>
      <div class="form-group">
        <label for="email">Enter Recruiter Email:</label>
        <input type="email" id="email" v-model="formData.email" required />
      </div>
      <div class="form-group">
        <label for="contact">Enter Recruiter Contact Number:</label>
        <input type="text" id="contact" v-model="formData.contact" required />
      </div>
      <div>
        <button type="submit" class="submit-button">Insert Recruiter Data</button>
      </div>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'AddRecruiter',
  data() {
    return {
      formData: {
        name: '',
        cityID: '',
        email: '',
        contact: ''
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
      axios.post("https://localhost:7077/api/Recruiter/AddRecruiter", this.formData)
        .then(response => {
          console.log(response);
          this.resetForm();
        })
        .catch(error => {
          console.error('Error inserting recruiter:', error);
        });
    },
    resetForm() {
      this.formData = {
        name: '',
        cityID: '',
        email: '',
        contact: ''
      };
    },
    updateCityID(event) {
      this.formData.cityID = event.target.value;
    }
  }
}
</script>

<style scoped>
.form {
  max-width: 600px;
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
