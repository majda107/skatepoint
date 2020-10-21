<template>
  <div class="map" ref="map">
    <l-map :zoom="zoom" :center="center" @click="addMarker">
      <!-- <l-map :zoom="zoom" :center="center"> -->
      <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
      <!-- <l-marker :lat-lng="marker" @click="selectMarker"></l-marker> -->
      <l-marker :lat-lng="marker"></l-marker>

      <!-- <l-marker :lat-lng="m" v-for="(m, i, k) in markers" :key="k"></l-marker> -->
    </l-map>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

import { LMap, LTileLayer, LMarker } from "vue2-leaflet";
import * as V2L from "vue2-leaflet";

import L from "leaflet";

// eslint-disable-next-line
delete (L.Icon.Default.prototype as any)._getIconUrl;
// eslint-disable-next-line
L.Icon.Default.mergeOptions({
  iconRetinaUrl: require("leaflet/dist/images/marker-icon-2x.png"),
  iconUrl: require("leaflet/dist/images/marker-icon.png"),
  shadowUrl: require("leaflet/dist/images/marker-shadow.png"),
});

export default Vue.extend({
  components: {
    LMap,
    LTileLayer,
    LMarker,
  },
  name: "MapComponent",

  data() {
    return {
      zoom: 13,
      center: L.latLng(47.41322, -1.219482),
      url: "http://{s}.tile.osm.org/{z}/{x}/{y}.png",
      attribution:
        '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors',
      marker: L.latLng(47.41322, -1.219482),
      //   markers: [] as any[],
    };
  },

  mounted: function () {
    // const container = this.$refs.map as HTMLElement;
    // container.appendChild(map.show());
  },

  methods: {
    addMarker: function (event: any) {
      this.marker = event.latlng;
      this.$emit("marker", event.latlng);
    },
  },
});
</script>

<style lang="scss" scoped>
@import "~leaflet/dist/leaflet.css";

.map {
  width: 100%;
  height: 100%;
}
</style>