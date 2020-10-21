<template>
  <div class="creator">
    <form>
      <label>Name</label>
      <input v-model="name" />
      <label>Type</label>
      <input v-model="type" />
      <label>Description</label>
      <input v-model="description" />
      <button type="button" @click="upload">Upload</button>
    </form>
    <div class="map">
      <map-component v-on:marker="setMarker"></map-component>
      <span>lat: {{ lat }} lng: {{ lng }}</span>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import MapComponent from "../components/MapComponent.vue";
import axios from "axios";
import { CONSTS } from "@/models/consts";
import { SkatePointModel } from "../models/skate-point-model";

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
    };
  },

  methods: {
    upload: async function () {
      const res = await axios.post(`${CONSTS.ENDPOINT}/skate/addpoint`, {
        name: this.name,
        lat: this.lat,
        lng: this.lng,
        description: this.description,
        type: this.type,
      } as SkatePointModel);

      console.log(res.data);
    },
    setMarker: async function (latlng: any) {
      console.log(latlng);
      this.lat = latlng.lat;
      this.lng = latlng.lng;
    },
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