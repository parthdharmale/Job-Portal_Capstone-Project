<template>
  <div>
    <div v-if="!isAuthenticated">
      <h1>Verify Recruiter Email</h1>
      <form @submit.prevent="verifyEmail" class="form">
        <div class="form-group">
          <label for="email">Enter Recruiter Email:</label>
          <input type="email" id="email" v-model="email" required />
        </div>
        <div class="form-group">
          <label for="otp">Enter OTP:</label>
          <input type="text" id="otp" v-model="otp" required />
        </div>
        <button type="submit" class="submit-button">Verify</button>
        <p v-if="message" :class="{'error': !isAuthenticated, 'success': isAuthenticated}">{{ message }}</p>
      </form>
    </div>
    <Navbar v-if="isAuthenticated" />
    <WelcomeRecruiterVue :recruiterName="rName" v-if="isAuthenticated" />
    <PostRecruiter v-if="!isAuthenticated && isEmailNotFound" />
  </div>
</template>

<script>
import axios from 'axios';

import Navbar from './NavbarComp.vue';
import PostRecruiter from './PostRecruiter.vue';
import WelcomeRecruiterVue from './WelcomeRecruiter.vue';

export default {
  name: 'EmailVerification',
  components: {
    Navbar,
    PostRecruiter,
    WelcomeRecruiterVue
  },
  data() {
    return {
      rName: '',
      email: '',
      otp: '',
      isAuthenticated: false,
      isEmailNotFound: false,
      message: ''
    };
  },
  methods: {
    async verifyEmail() {
      const hardcodedOTP = '123456'; 

      if (this.otp !== hardcodedOTP) {
        this.message = 'Invalid OTP.';
        this.isAuthenticated = false;
        return;
      }

      try {
        const response = await axios.get(`https://localhost:7077/api/Recruiter/CheckEmail/${this.email}`);

        if (response.data.exists) {
            console.log(response.data)
          this.rName = response.data.name;
          console.log('Recruiter Name:', this.rName);
          this.isAuthenticated = true;
          this.isEmailNotFound = false;
          localStorage.setItem('adminLogged', "yes");
          this.message = 'Email verified successfully.';
        } else {
          this.recruiterName = null;
          this.isAuthenticated = false;
          this.isEmailNotFound = true;
          this.message = 'Email not found. Please register.';
        }
      } catch (error) {
        console.error('Error verifying email:', error);
        this.message = 'An error occurred while verifying the email.';
        this.isAuthenticated = false;
        this.isEmailNotFound = false;
      }
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

.error {
  color: red;
}

.success {
  color: green;
}
</style>
