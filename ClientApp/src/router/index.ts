import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'

import LandingView from "../views/LandingView.vue";
import LoginView from "../views/LoginView.vue";
import QueryView from "../views/QueryView.vue";
import SchoolView from "../views/SchoolView.vue";

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Landing',
    component: LandingView
  },
  {
    path: "/login",
    name: "Login",
    component: LoginView
  },
  {
    path: "/search",
    name: "Search",
    component: QueryView
  },
  {
    path: "/school/:ico",
    name: "School",
    component: SchoolView
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
