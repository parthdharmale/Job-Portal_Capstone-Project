<template>
  <div>
    
    <AdminLogin v-if="!isAdminLoggedIn" @login-success="handleLoginSuccess" />
    <div v-else>
      <AdminNavbarVue/>
      <h1>Admin Dashboard</h1>
      <p>Welcome, Admin!</p>
      
    </div>
  </div>
</template>

<script>
import AdminLogin from './AdminLogin.vue';
import AdminNavbarVue from './AdminNavbar.vue';

// import DeleteRecruiter from './DeleteRecruiter.vue'; // Example component

export default {
  name: 'AdminDashboard',
  components: {
    AdminLogin,
    AdminNavbarVue,
    // DeleteRecruiter,
  },
  data() {
    return {
      isAdminLoggedIn: false, // Set this based on your authentication logic
    };
  },
  methods: {
    handleLoginSuccess() {
      this.isAdminLoggedIn = true;
    },
  },
};
</script>

<style scoped>
/* Add your styles here */
</style>
