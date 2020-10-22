import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'

import LandingView from "../views/LandingView.vue";
import LoginView from "../views/LoginView.vue";
import QueryView from "../views/QueryView.vue";
import SchoolView from "../views/SchoolView.vue";
import MapView from "../views/MapView.vue";
import RegisterView from "../views/RegisterView.vue"
import ProfileView from "../views/ProfileView.vue"
import CreatorView from "../views/CreatorView.vue"
import DocumentationView from "../views/DocumentationView.vue"

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
    path: "/register",
    name: "Register",
    component: RegisterView
  },
  {
    path: "/map",
    name: "Map",
    component: MapView
  },
  {
    path: "/creator",
    name: "Creator",
    component: CreatorView
  },
  {
    path: "/profile",
    name: "Profile",
    component: ProfileView
  },
  {
    path: "/documentation",
    name: "Documentation",
    component: DocumentationView
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
