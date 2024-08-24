<template>
  <nav class="navbar">
    <ul>
      <!-- <li><router-link to="/">Home</router-link></li> -->
      <li><router-link to="/get-job">Get Open Jobs</router-link></li>
      <li><router-link to="/get-app-by-cid">Get Your Applications</router-link></li>
      <li><router-link to="/update-profile">Update Personal Info</router-link></li>
      <li><router-link to="/update-education">Update Professional Info</router-link></li>

      
    </ul>
  </nav>
</template>

<script>
export default {
  name: 'CandidateNavbar'
}
</script>

<style scoped>
.navbar {
  background-color: #f8f9fa;
  padding: 10px;
  border-bottom: 1px solid #ddd;
}

ul {
  list-style-type: none;
  padding: 0;
  margin: 0;
  display: flex;
}

li {
  margin-right: 15px;
}

a {
  text-decoration: none;
  color: #007bff;
  font-size: 16px;
}

a:hover {
  text-decoration: underline;
}
</style>
