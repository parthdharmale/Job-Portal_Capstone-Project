<template>
  <div>
    <h1>Admin List</h1>
    <div v-if="loading">Loading...</div>
    <div v-if="error" class="error">{{ error }}</div>
    
    <div>

    
    <table v-if="admins.length" class="admin-table">
      <thead>
        <tr>
          <th>Admin ID</th>
          <th>Admin Name</th>
          <th>Username</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="admin in admins" :key="admin.adminID">
          <td>{{ admin.adminID }}</td>
          <td>{{ admin.adminName }}</td>
          <td>{{ admin.userName }}</td>
        </tr>
      </tbody>
    </table>
    <div v-else>No admins found.</div>

    </div>
  </div>
</template>
<script>
import axios from 'axios';

export default {
  data() {
    return {
      admins: [],
      loading: false,
      error: null,
    };
  },
  methods: {
    async fetchAdmins() {
      this.loading = true;
      this.error = null;

      try {
        const token = localStorage.getItem('authToken'); // Replace with how you manage auth tokens

        if (!token) {
          throw new Error("Authentication token not found.");
        }

        const response = await axios.get('https://localhost:7077/api/Admin/GetAdmins', {
          headers: {
            'Authorization': `Bearer ${token}`,
          },
        });
        console.log(response);
        this.admins = response.data;
      } catch (err) {
        this.error = err.response?.data?.message || err.message || "An error occurred while fetching admins.";
      } finally {
        this.loading = false;
      }
    },
  },
  mounted() {
    this.fetchAdmins();
  },
};
</script>

<style scoped>
.error {
  color: red;
  margin-top: 10px;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th, td {
  border: 1px solid #ddd;
  padding: 8px;
}

th {
  background-color: #f4f4f4;
}
</style>
