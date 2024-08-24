<template>
  <nav class="navbar">
    <ul>
      <!-- <li><router-link to="/">Home</router-link></li> -->
      <li><router-link to="/get-job">Get Job</router-link></li>
      <!-- <li><router-link to="/post-job">Post Job</router-link></li> -->
      <li><router-link to="/get-application">Get Application</router-link></li>
      <li><router-link to="/get-all-candidates">Show Candidates</router-link></li>
      <li><router-link to="/get-all-recruiters">Show Recruiters</router-link></li>
      <li><router-link to="/delete-recruiter">Delete Recruiter</router-link></li>
      <li><router-link to="/delete-candidate">Delete Candidate</router-link></li>
      <li><router-link to="/get-admin">Get Admin</router-link></li>
      <li><router-link to="/get-job-by-RID">Get Jobs By Recruiter</router-link></li>

      

      
    </ul>
  </nav>
</template>

<script>
export default {
  name: 'NavbarComp'
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
