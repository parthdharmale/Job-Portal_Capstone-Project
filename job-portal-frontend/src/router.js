// src/router/index.js
import { createRouter, createWebHistory } from 'vue-router';
import GetJob from '@/components/GetJob.vue';
import PostJob from '@/components/PostJob.vue';
import GetApplication from '@/components/GetApplication.vue';
import PostRecruiter from '@/components/PostRecruiter.vue';
import GetAppByJID from '@/components/GetAppByJID.vue'
import GetJobByRID from '@/components/GetJobByRID.vue'
import ShowCandidates from '@/components/ShowCandidates.vue';
import ShowRecruiters from '@/components/ShowRecruiters.vue';
import DeleteRecruiter from '@/components/DeleteRecruiter.vue';
import DeleteCandidate from '@/components/DeleteCandidate.vue';
import GetAdmin from '@/components/GetAdmin.vue';
// import HomePage from '@/components/UserSelection.vue';
const routes = [
  // { path: '/', component: HomePage },
  { path: '/get-job', component: GetJob },
  { path: '/post-job', component: PostJob },
  { path: '/get-application', component: GetApplication },
  { path: '/post-recruiter', component: PostRecruiter },
  { path: '/get-application-by-JID', component: GetAppByJID },
  { path: '/get-job-by-RID', component: GetJobByRID },
  { path: '/get-all-candidates', component: ShowCandidates },
  { path: '/get-all-recruiters', component: ShowRecruiters },
  { path: '/delete-recruiter', component: DeleteRecruiter },
  { path: '/delete-candidate', component: DeleteCandidate },
  { path: '/get-admin', component: GetAdmin },

];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
