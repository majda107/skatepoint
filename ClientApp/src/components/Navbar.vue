<template>
  <section class="nav">
    <div class="nav-content main-wrapper">
      <div class="nav-content-title">
        <div class="nav-content-title-logo">
          <router-link to="/">
            <h1>Skatepoint</h1>
          </router-link>
        </div>
      </div>
      <div
        class="nav-content-menu"
        v-bind:class="{ isMobileOpened: isMobileOpened }"
      >
        <ul class="nav-content-menu-items">
          <router-link to="/map" class="nav-content-menu-items-item">
            <li class="nav-content-menu-items-item">Mapa</li>
          </router-link>

          <router-link to="/creator">
            <li class="nav-content-menu-items-item">Přidat spot</li>
          </router-link>

          <router-link to="/profile">
            <li class="nav-content-menu-items-item">Profil</li>
          </router-link>

          <template v-if="getLoggedIn">
            <li
              class="nav-content-menu-items-item btn-s btn-primary"
              style="margin-left: 24px"
              @click="logout()"
            >
              Logout
            </li>
          </template>

          <template v-else>
            <router-link to="/login" v-if="!getLoggedIn">
              <li class="nav-content-menu-items-item btn-s btn-secondary">
                Přihlásit
              </li>
            </router-link>
            <router-link to="/register" v-if="!getLoggedIn">
              <li class="nav-content-menu-items-item btn-s btn-primary">
                Registrovat
              </li>
            </router-link>
          </template>
        </ul>
        <div class="hamburger-container">
          <div class="hamburger" v-on:click="() => ToggleMobile()">
            <div></div>
            <div></div>
            <div></div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script lang="ts">
import Vue from "vue";
import { mapActions, mapGetters } from "vuex";
export default Vue.extend({
  name: "Navbar",
  data: function () {
    return {
      isMobileOpened: false,
    };
  },
  computed: {
    ...mapGetters(["getLoggedIn", "getUsername"]),
  },
  methods: {
    ...mapActions(["setEmpty"]),
    ToggleMobile: function () {
      this.isMobileOpened = !this.isMobileOpened;
    },
    logout: async function () {
      this.setEmpty();
    },
  },
  watch: {
    $route(to, from) {
      this.isMobileOpened = false;
    },
  },
});
</script>

<style scoped lang="scss">
@import "../../styles/main.scss"; // nav {
//   height: 72px;
//   .nav-primary {
//     margin-right: 400px;
//     position: relative;
//     top: 50%;
//     transform: translateY(-50%);
//   }
//   .nav-secondary {
//     display: inline-block;
//     a{
//       margin-right: 10px;
//     }
//     position: relative;
//     top: 50%;
//     transform: translateY(-50%);
//   }
// }
</style>
