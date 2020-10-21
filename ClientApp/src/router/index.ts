import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'

import LandingView from "../views/LandingView.vue";
import LoginView from "../views/LoginView.vue";

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
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
