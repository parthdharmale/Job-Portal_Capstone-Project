<template>
  <div>
    <h1>Apply to Job</h1>
    <form @submit.prevent="insertDetails" class="form">
      <div class="form-group">
        <label for="jobID">Enter Job ID:</label>
        <input type="text" id="jobID" v-model="formData.jobID" required>
      </div>
      <div class="form-group">
        <label for="candidateID">Enter Candidate ID:</label>
        <input type="text" id="candidateID" v-model="formData.cid" required>
      </div>
      <div class="form-group">
        <label for="resume">Enter Resume Link:</label>
        <input type="text" id="resume" v-model="formData.resume" required>
      </div>
      <div class="form-group">
        <label for="skills">Enter Your Skills:</label>
        <input type="text" id="skills" v-model="formData.skills" required>
      </div>

      <div>
        <button type="submit" class="submit-button">Apply To The Job</button>
      </div>
    </form>
    <button @click="goBack" class="back-button">Back to Selection</button>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'AddApplication',
  props: ['jobID','candidateID'],
  data() {
    return {
      formData: {
        jobID: this.jobID,
        cid: this.candidateID,
        resume: '',
        skills: '',
        status: 'Applied',
        dateOfApplication: new Date().toISOString().split('T')[0],
      }
    };
  },
  methods: {
    insertDetails() {
      axios.post("https://localhost:7077/api/Application/AddApplication", this.formData)
        .then(response => {
          console.log(response);
          // Optionally clear the form or show a success message
          this.resetForm();
        })
        .catch(error => {
          console.error('Error:', error.response?.data || error.message);
        });
    },
    goBack() {
      this.$emit('back-to-selection');
      console.log("Back button clicked")
    },
    resetForm() {
      this.formData = {
        jobID: this.jobID,
        cid: this.candidateID,
        resume: '',
        skills: '',
        status: 'Applied',
        dateOfApplication: new Date().toISOString().split('T')[0],
      };
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

input {
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
}

.back-button:hover {
  background-color: #5a6268;
}
</style>
