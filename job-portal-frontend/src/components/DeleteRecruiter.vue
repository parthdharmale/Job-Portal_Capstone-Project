<template>
  <div>
    <h1>Delete Recruiter</h1>
    <form @submit.prevent="deleteRecruiter">
      <div>
        <label for="recruiterID">Recruiter ID:</label>
        <input v-model="recruiterID" type="number" id="recruiterID" required />
      </div>
      <button type="submit" class="submit-button">Delete Recruiter</button>
    </form>
    <p v-if="message">{{ message }}</p>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'DeleteRecruiter',
  data() {
    return {
      recruiterID: '',
      message: ''
    };
  },
  methods: {
    deleteRecruiter() {
      axios.delete(`https://localhost:7077/api/Recruiter/DeleteRecruiter/${this.recruiterID}`)
        .then(response => {
          this.message = 'Recruiter deleted successfully!';
          console.log(response);
        })
        .catch(error => {
          console.error("There was an error deleting the recruiter!", error);
          this.message = 'Error deleting recruiter. Please try again.';
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
