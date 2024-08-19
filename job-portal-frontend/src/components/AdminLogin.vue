<template>
  <div>
    <h2>Login With Your Credentials</h2>
    <form @submit.prevent="checkCredentials" class="form">
      <div class="form-group">
        <label for="email">Username:</label>
        <input v-model="credentials.email" type="email" id="email" required />
      </div>
      <div class="form-group">
        <label for="password">Password:</label>
        <input v-model="credentials.password" type="password" id="password" required />
      </div>
      <button type="submit" class="submit-button">Check Credentials</button>
    </form>
    <p v-if="message" :class="{'error': !isValid, 'success': isValid}">{{ message }}</p>
  </div>
</template>

<script>
import { ref } from 'vue';
import axios from 'axios';

export default {
  name: 'AdminLogin',
  setup(props, { emit }) {
    const credentials = ref({
      email: '',
      password: ''
    });
    const message = ref('');
    const isValid = ref(false);
    const adminId = ref(0);

    const checkCredentials = async () => {
      try {
        const response = await axios.post('https://localhost:7077/api/Admin/CheckAdminCredentials', credentials.value);

        if (response.status === 200) {
          adminId.value = response.data.adminId;

          console.log(response.data.adminId);
          emit('login-success',adminId.value);
          
          message.value = 'Login successful';
          isValid.value = true;
        } else {
          message.value = 'Invalid credentials';
          isValid.value = false;
        }
      } catch (error) {
        if (error.response) {
          message.value = error.response.data;
        } else {
          message.value = 'An error occurred while checking credentials.';
        }
        isValid.value = false;
      }
    };

    return {
      credentials,
      message,
      isValid,
      checkCredentials
    };
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
