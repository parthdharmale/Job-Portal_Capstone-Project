<template>
  <div>
    <h2>Login With Your Credentials</h2>
    <form @submit.prevent="checkCredentials" class="form">
      <div class="form-group">
        <label for="email">Email:</label>
        <input v-model="credentials.email" type="email" id="email" required />
      </div>
      <div class="form-group">
        <label for="password">Password:</label>
        <input v-model="credentials.password" type="password" id="password" required />
      </div>
      <button type="submit" class="submit-button">Check Credentials</button> 
    </form>
    <p v-if="message" :class="{'error': !isValid, 'success': isValid}">
      Invalid Email or Password
      
    </p>
    <button @click="buttonClicked" class="submit-button">
      Or else Signup
    </button>
    <CandidateSignupVue v-if="(message && !isValid) || isClicked" />
  </div>
</template>

<script>
import { ref } from 'vue';
import axios from 'axios';

import CandidateSignupVue from './CandidateSignup.vue';
export default {
  name: 'CandidateLogin',
  components:{
    CandidateSignupVue,
  },
  setup(props, { emit }) {
    const credentials = ref({
      email: '',
      password: ''
    });
    const message = ref('');
    const isValid = ref(false);
    const candidateId = ref(0);
    

    const checkCredentials = async () => {
      try {
        localStorage.removeItem("adminLogged");
        const response = await axios.post('https://localhost:7077/api/Candidate/CheckCandidateCredentials', credentials.value);

        if (response.status === 200) {
          candidateId.value = response.data.candidateId;
          // console.log(response);
          localStorage.setItem("CID", candidateId.value);
          console.log(response.data.candidateId);
          emit('login-success',candidateId.value);
          
          message.value = 'Login successful';
          isValid.value = true;
        } else {
          message.value = 'Invalid credentials';
          isValid.value = false;
          
          // console.log("tried" + this.tried);
          // console.log("isvalid" + isValid.value);
        }
      } catch (error) {
        // this.tried = true;
        // console.log("tried" + this.tried);
          // console.log("isvalid" + isValid.value);
        if (error.response) {
          // Server responded with a status other than 2xx
          message.value = error.response.data;
        } else {
          // Network error or no response from server
          message.value = 'An error occurred while checking credentials.';
        }
        isValid.value = false;
      }
    };

    return {
      credentials,
      message,
      isValid,
      checkCredentials,
      
    };
  },
  data(){
    return{
      // tried : false,
      isClicked: false,
    }
  },
  methods:{
    buttonClicked(){
      this.isClicked = true;
    }
  }
};
</script>

<style scoped>
.error {
  color: red;
}
.success {
  color: green;
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
</style>
