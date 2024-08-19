<template>
  <div>
    <h1>Welcome to the Job Portal</h1>
    <button @click="setUserType('candidate')" class="submit-button">I am a Candidate</button>
    <button @click="setUserType('recruiter')" class="submit-button">I am a Recruiter</button>
    <button @click="setUserType('admin')" class="submit-button">I am a Admin</button>
  </div>
</template>

<script>
export default {
  name: 'UserSelection',
  methods: {
    setUserType(type) {
      this.$emit('user-type-selected', type);
    }
  }
}
</script>

<style>
/* Add your styles here */



.submit-button {
  background-color: #007bff;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
  margin-top: 10px;
  margin-right: 20px;
  margin-left: 20px;
}
</style>
