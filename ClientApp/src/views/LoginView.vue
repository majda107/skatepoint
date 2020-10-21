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
import { mapActions } from "vuex";

export default Vue.extend({
  name: "LoginView",
  methods: {
    ...mapActions(["setLogin"]),
    login: async function () {
      try {
        const res = await axios.post(`${CONSTS.ENDPOINT}/auth/login`, {
          // const res = await axios.post("https://localhost:5001/auth/login", {
          UserName: this.username,
          Password: this.password,
        });

        this.setLogin(res.data);
        this.$router.push("/");
      } catch (e) {
        console.log("Couldn't login!");
      }
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