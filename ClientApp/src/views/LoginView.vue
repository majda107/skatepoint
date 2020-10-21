<template>
  <div>
    <input v-model="username" />
    <input v-model="password" type="password" />
    <button @click="this.login">Login</button>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import axios from "axios";
import { CONSTS } from "@/models/consts";

export default Vue.extend({
  name: "LoginView",
  methods: {
    login: async function () {
      const res = await axios.post(`${CONSTS.ENDPOINT}/auth/login`, {
        // const res = await axios.post("https://localhost:5001/auth/login", {
        UserName: this.username,
        Password: this.password,
      });
      console.log(res.data);
    },
  },
  data: function () {
    return {
      username: "",
      password: "",
    };
  },
});
</script>