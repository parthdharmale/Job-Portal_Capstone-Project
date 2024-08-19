<template>
  <div>
    <CandidateLoginVue 
      v-if="userType === 'candidate' && !isLoggedIn" 
      @login-success="handleLoginSuccess" 
    />

    <AdminPageVue v-if="userType === 'admin' "/>

    
    <UserSelection 
      v-if="!userType && isHomePage" 
      @user-type-selected="handleUserTypeSelected" 
    />
    
    <div v-if="isLoggedIn">
      <div v-if="userType === 'candidate' && !currentView">
        <GetJobVue @apply-job="showPostApplication" />
        <GetAppByCIDVue :candidateID="candidateID" />
        <UpdateCandidateVue :cid="candidateID"/>
      </div>

      <div v-if="userType === 'candidate' && currentView === 'PostApplication'">
        <PostApplicationVue :jobID="selectedJobID" :candidateID="candidateID" @back-to-selection="goBackToSelection" />
      </div>

    </div>
    <RecruiterPageVue v-if="userType === 'recruiter'" />  
    <router-view />
  </div>
</template>

<script>
import GetJobVue from './components/GetJob.vue';
import PostApplicationVue from './components/PostApplication.vue';
import UserSelection from './components/UserSelection.vue';

// import Navbar from './components/NavbarComp.vue';
import GetAppByCIDVue from './components/GetAppByCID.vue';
import CandidateLoginVue from './components/CandidateLogin.vue';
import RecruiterPageVue from './components/RecruiterPage.vue';
import UpdateCandidateVue from './components/UpdateCandidate.vue';
import AdminPageVue from './components/AdminPage.vue';
export default {
  name: 'App',
  components: {
    GetJobVue,
    GetAppByCIDVue,
    CandidateLoginVue,
    PostApplicationVue,
    UserSelection,
    UpdateCandidateVue,
    AdminPageVue,
    // Navbar,
    RecruiterPageVue
  },
  data() {
    return {
      userType: null,
      currentView: null,
      selectedJobID: null,
      isLoggedIn: false,
      candidateID: null,
    };
  },
  computed: {
    isHomePage() {
      return this.$route.path === '/';
    }
  },
  methods: {
    handleUserTypeSelected(type) {
      this.userType = type;
    },
    handleLoginSuccess(candidateID) {
      this.isLoggedIn = true;
      this.candidateID = candidateID;
    },
    goBackToSelection() {
      this.currentView = null;
      this.userType = null;
      this.isLoggedIn = false; 
    },
    showPostApplication(jobID) {
      this.selectedJobID = jobID;
      this.currentView = 'PostApplication';
    },
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
