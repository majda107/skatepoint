<template>
  <div class="creator">
    <template v-if="getLoggedIn">
      <form>
        <label>Name</label>
        <input v-model="name" v-debounce:500ms="debounce" />
        <ul>
          <li v-for="(p, i, k) in places" :key="k">{{ p.name }}</li>
        </ul>

        <label>Type</label>
        <input v-model="type" />
        <label>Description</label>
        <input v-model="description" />

        <label>Image</label>
        <input type="file" ref="fileInput" />

        <button type="button" @click="upload">Upload</button>
      </form>
      <div class="map">
        <map-component v-on:marker="setMarker"></map-component>
        <span>lat: {{ lat }} lng: {{ lng }}</span>
      </div>
    </template>
    <template v-else>
      <span>... please login</span>
    </template>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

import vueDebounce from "vue-debounce";
Vue.use(vueDebounce);

import MapComponent from "../components/MapComponent.vue";
import axios from "axios";
import { CONSTS } from "@/models/consts";
import { SkatePointModel } from "../models/skate-point-model";
import { KnownPlaceModel } from "../models/known-place-model";
import { mapGetters } from "vuex";
import router from "@/router";

export default Vue.extend({
  name: "CreatorView",
  components: {
    MapComponent,
  },
  data: function () {
    return {
      name: "",
      type: "",
      description: "",
      lat: 0,
      lng: 0,
      places: [] as KnownPlaceModel[],
    };
  },

  methods: {
    upload: async function () {
      const fileInput = this.$refs.fileInput as HTMLInputElement;
      const file = fileInput?.files?.item(0) ?? null;

      if (file == null) {
        console.log("Invalid file count!");
        return;
      }

      let res = await axios.post(
        `${CONSTS.ENDPOINT}/skate/addpoint`,
        {
          name: this.name,
          lat: this.lat,
          lng: this.lng,
          description: this.description,
          type: this.type,
        } as SkatePointModel,
        {
          headers: {
            Authorization: `Bearer ${this.getToken}`,
          },
        }
      );

      console.log(res.data);

      const form = new FormData();
      form.append("files", file);
      form.append("id", res.data.id);

      res = await axios.put(`${CONSTS.ENDPOINT}/skate/putpointimage`, form, {
        headers: {
          Authorization: `Bearer ${this.getToken}`,
        },
      });

      this.$router.push("/map");
    },
    setMarker: async function (latlng: any) {
      console.log(latlng);
      this.lat = latlng.lat;
      this.lng = latlng.lng;
    },
    debounce: async function () {
      const res = await axios.get(
        `${CONSTS.ENDPOINT}/skate/getknownplaces?name=${this.name}`
      );

      const places: KnownPlaceModel[] = res.data as KnownPlaceModel[];
      this.places = places;
    },
  },

  created: async function () {
    if (!this.getLoggedIn) {
      this.$router.push("/login");
      return;
    }
  },

  computed: {
    ...mapGetters(["getLoggedIn", "getToken"]),
  },
});
</script>

<style lang="scss" scoped>
.creator {
  display: grid;
  grid-template-columns: 1fr auto;
  grid-template-rows: auto;
}

.map {
  width: 600px;
  height: 460px;
}

form {
  display: flex;
  flex-flow: column;
}
</style>