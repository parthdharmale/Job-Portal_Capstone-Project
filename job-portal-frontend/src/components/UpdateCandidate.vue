<template>
  <div>
    <h1>Want To Update Your Profile?</h1>
    <button class="submit-button" v-if="!updateClicked" @click="updateTriggered"> Click Here To Update</button>
    <form v-if="updateClicked" @submit.prevent="updateCandidate" class="form">
      <div class="form-group">
        <label for="firstName">First Name:</label>
        <input v-model="candidate.firstName" type="text" id="firstName" class="form-control" />
      </div>
      <div class="form-group">
        <label for="lastName">Last Name:</label>
        <input v-model="candidate.lastName" type="text" id="lastName" class="form-control" />
      </div>
      <div class="form-group">
        <label for="email">Email:</label>
        <input v-model="candidate.email" type="email" id="email" class="form-control" />
      </div>
      <div class="form-group">
        <label for="password">Password:</label>
        <input v-model="candidate.password" type="password" id="password" class="form-control" />
      </div>
      <div class="form-group">
        <label for="dob">Date of Birth:</label>
        <input v-model="candidate.dob" type="date" id="dob" class="form-control" />
      </div>
      <div class="form-group">
        <label for="address">Address:</label>
        <textarea v-model="candidate.address" id="address" class="form-control"></textarea>
      </div>
      <div class="form-group">
        <label for="contact">Contact:</label>
        <input v-model="candidate.contact" type="tel" id="contact" class="form-control" />
      </div>
      <div class="form-group">
        <label for="city">City:</label>
        <!-- <input v-model="candidate.cityID" type="number" id="city" class="form-control" /> -->
        <select id="city" v-model="candidate.cityID" required>
          <option value="" disabled>Select a city</option>
          <option v-for="city in cities" :key="city.id" :value="city.cityID">
            {{ city.cityName }}
          </option>
        </select>
      </div>
      <div class="form-group">
        <label for="state">State:</label>
        <input v-model="candidate.stateID" type="number" id="state" class="form-control" />
      </div>
      <div class="form-group">
        <label for="country">Country:</label>
        <input v-model="candidate.countryID" type="number" id="country" class="form-control" />
      </div>
      <div>
        <button type="submit" class="submit-button">Update</button>
      </div>

      
    </form>
    <div v-if="message" class="alert alert-info">{{ message }}</div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'UpdateCandidate',
  data() {
    return {
      candidate: {
        firstName: '',
        lastName: '',
        email: '',
        password: '',
        dob: '',
        address: '',
        contact: '',
        cityID: null,
        stateID: null,
        countryID: null
      },
      cities:[],
      message: '',
      updateClicked: false,
    };
  },
  props: ['cid'], 
  created() {
    this.fetchCandidate();
    this.fetchCities();
  },
  methods: {
    async fetchCandidate() {
      try {
        
        const response = await axios.get(`https://localhost:7077/api/Candidate/GetCandidateByID/${this.cid}`);
        this.candidate = response.data;
      } catch (error) {
        console.error('Error fetching candidate:', error);
        this.message = 'Failed to load candidate details.';
      }
    },
    async updateTriggered(){
        this.updateClicked = true;
    },
    async fetchCities() {
      try {
        const response = await axios.get('https://localhost:7077/api/City/GetAllCities'); 
        this.cities = response.data; 
      } catch (error) {
        console.error('Error fetching cities:', error);
       
      }
    },
    async updateCandidate() {
      try {
        const patchData = this.preparePatchData();
        await axios.patch(`https://localhost:7077/api/Candidate/UpdateCandidate/${this.cid}`, patchData, {
          headers: {
            'Content-Type': 'application/json-patch+json'
          }
        });
        this.message = 'Update successful';
      } catch (error) {
        console.error('Error updating candidate:', error);
        this.message = 'Update failed';
      }
    },
    preparePatchData() {
      const patchData = [];

  // Add operations only for fields that are present and different from the original
  if (this.candidate.firstName) patchData.push({ op: 'replace', path: '/firstName', value: this.candidate.firstName });
  if (this.candidate.lastName) patchData.push({ op: 'replace', path: '/lastName', value: this.candidate.lastName });
  if (this.candidate.email) patchData.push({ op: 'replace', path: '/email', value: this.candidate.email });
  if (this.candidate.password) patchData.push({ op: 'replace', path: '/password', value: this.candidate.password });
  if (this.candidate.dob) patchData.push({ op: 'replace', path: '/dob', value: this.candidate.dob });
  if (this.candidate.address) patchData.push({ op: 'replace', path: '/address', value: this.candidate.address });
  if (this.candidate.contact) patchData.push({ op: 'replace', path: '/contact', value: this.candidate.contact });
  if (this.candidate.cityID !== null) patchData.push({ op: 'replace', path: '/cityID', value: this.candidate.cityID });
  if (this.candidate.stateID !== null) patchData.push({ op: 'replace', path: '/stateID', value: this.candidate.stateID });
  if (this.candidate.countryID !== null) patchData.push({ op: 'replace', path: '/countryID', value: this.candidate.countryID });

  return patchData;
    }
  }
};
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

input, textarea {
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

.alert-info {
  margin-top: 20px;
  padding: 15px;
  background-color: #e7f0ff;
  border: 1px solid #b3d7ff;
  border-radius: 4px;
}
</style>
