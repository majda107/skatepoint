<template>
  <div class="auth main-wrapper">
      <div class="auth-content">
          <h2>Přihlášení uživatele</h2>
          <input v-model="username" type="text" class="input-s mt-32 width-100p" placeholder="username" >
          <input v-model="password" type="password"  class="input-s mt-24 width-100p" placeholder="Heslo">
          <button @click="this.login" class="btn-m btn-primary mt-24 width-100p">Přihlásit</button>
      </div>
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

<style scoped lang="scss">
@import "../../styles/main.scss";
@import "../../styles/layout/auth.scss";
</style>