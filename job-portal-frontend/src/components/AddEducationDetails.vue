<template>
  <div>
    <h1>Add Your Education Details And Work Experience</h1>
    <button class="submit-button" v-if="!updateClicked" @click="updateTriggered"> Click Here To Add</button>
    <form v-if="updateClicked" @submit.prevent="updateCandidate" class="form">
      <div class="form-group">
        <label for="education1">Education 1:</label>
        <input v-model="candidate.education1" type="text" id="education1" class="form-control" />
      </div>
      <div class="form-group">
        <label for="educationResult1">Education Result 1:</label>
        <input v-model="candidate.educationResult1" type="number" id="educationResult1" class="form-control" />
      </div>
      <div class="form-group">
        <label for="educationPassoutYear1">Education 1 Completion Year:</label>
        <input v-model="candidate.educationPassoutYear1" type="text" id="educationPassoutYear1" class="form-control" />
      </div>
      <div class="form-group">
        <label for="education2">Education 2:</label>
        <input v-model="candidate.education2" type="text" id="education2" class="form-control" />
      </div>
      <div class="form-group">
        <label for="educationResult2">Education Result 2:</label>
        <input v-model="candidate.educationResult2" type="number" id="educationResult2" class="form-control" />
      </div>
      <div class="form-group">
        <label for="educationPassoutYear2">Education 2 Completion Year:</label>
        <input v-model="candidate.educationPassoutYear2" type="email" id="educationPassoutYear2" class="form-control" />
      </div>
      <div class="form-group">
        <label for="education3">Education 3:</label>
        <input v-model="candidate.education3" type="text" id="education3" class="form-control" />
      </div>
      <div class="form-group">
        <label for="educationResult3">Education Result 3:</label>
        <input v-model="candidate.educationResult3" type="number" id="educationResult3" class="form-control" />
      </div>
      <div class="form-group">
        <label for="educationPassoutYear3">Education 3 Completion Year:</label>
        <input v-model="candidate.educationPassoutYear3" type="text" id="educationPassoutYear3" class="form-control" />
      </div>
      <div>
        <button type="submit" class="submit-button">Add</button>
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
        education1: '',
        educationResult1: null,
        educationPassoutYear1: '',
        education2: '',
        educationResult2: null,
        educationPassoutYear2: '',
        education3: '',
        educationResult3: null,
        educationPassoutYear3: '',
      },
      cities:[],
      message: '',
      updateClicked: false,
    };
  },
  props: ['cid'], 
  created() {
    this.fetchCandidate();
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
    
    async updateCandidate() {
      try {
        // const cid = localStorage.getItem("CID");
        const patchData = this.preparePatchData();
        await axios.patch(`https://localhost:7077/api/Candidate/UpdateCandidate/${this.cid}`, patchData, {
          headers: {
            'Content-Type': 'application/json-patch+json'
          }
        });
        this.message = 'Details Added successfully';
      } catch (error) {
        console.error('Error updating candidate:', error);
        this.message = 'Update failed';
      }
    },
    preparePatchData() {
      const patchData = [];

  // Add operations only for fields that are present and different from the original
  if (this.candidate.education1) patchData.push({ op: 'replace', path: '/education1', value: this.candidate.education1 });
  if (this.candidate.educationResult1 !== null) patchData.push({ op: 'replace', path: '/educationResult1', value: this.candidate.educationResult1 });
  if (this.candidate.educationPassoutYear1) patchData.push({ op: 'replace', path: '/educationPassoutYear1', value: this.candidate.educationPassoutYear1 });
  if (this.candidate.education2) patchData.push({ op: 'replace', path: '/education2', value: this.candidate.education2 });
  if (this.candidate.educationResult2 !== null) patchData.push({ op: 'replace', path: '/educationResult2', value: this.candidate.educationResult2 });
  if (this.candidate.educationPassoutYear2) patchData.push({ op: 'replace', path: '/educationPassoutYear2', value: this.candidate.educationPassoutYear2 });
  if (this.candidate.education3) patchData.push({ op: 'replace', path: '/education3', value: this.candidate.education3 });
  if (this.candidate.educationResult3 !== null) patchData.push({ op: 'replace', path: '/educationResult3', value: this.candidate.educationResult3 });
  if (this.candidate.educationPassoutYear3 ) patchData.push({ op: 'replace', path: '/stateID', value: this.candidate.stateID });


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
