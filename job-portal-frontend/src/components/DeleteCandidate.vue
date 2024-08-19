<template>
  <div>
    <h1>Delete Candidate</h1>
    <form @submit.prevent="deleteCandidate">
      <div>
        <label for="candidateID">Candidate ID:</label>
        <input v-model="candidateID" type="number" id="candidateID" required />
      </div>
      <button type="submit" class="submit-button">Delete Candidate</button>
    </form>
    <p v-if="message">{{ message }}</p>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'DeleteCandidate',
  data() {
    return {
      candidateID: '',
      message: ''
    };
  },
  methods: {
    deleteCandidate() {
      axios.delete(`https://localhost:7077/api/Candidate/DeleteCandidate/${this.candidateID}`)
        .then(response => {
          this.message = 'Candidate deleted successfully!';
          console.log(response);
        })
        .catch(error => {
          console.error("There was an error deleting the candidate!", error);
          this.message = 'Error deleting candidate. Please try again.';
        });
    }
  }
};
</script>

<style scoped>
form {
  margin-top: 20px;
}

div {
  margin-bottom: 10px;
}

label {
  margin-right: 10px;
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
