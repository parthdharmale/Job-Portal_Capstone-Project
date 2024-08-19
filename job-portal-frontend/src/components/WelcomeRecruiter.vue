<template>
  <div v-if="recruiterName">
    <h1>Welcome, {{ recruiterName }}!</h1>
    <p>We're glad to have you here. What do you want to do today?</p>
  </div>
</template>

<script>
export default {
  name: 'WelcomeRecruiterVue',
  props: {
    recruiterName: {
      type: String,
      required: true
    }
  }
}
</script>

<style scoped>
h1 {
  font-size: 24px;
  color: #007bff;
}

p {
  font-size: 16px;
  color: #333;
}
</style>
