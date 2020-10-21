<template>
  <div class="main-wrapper">
    <div class="main-title">
        <h2>Mapa spotů</h2>
    </div>
    <div class="map" ref="map">
      <!-- <l-map :zoom="zoom" :center="center" @click="addMarker"> -->
      <l-map :zoom="zoom" :center="center">
        <l-tile-layer :url="url" :attribution="attribution"></l-tile-layer>
        <!-- <l-marker :lat-lng="marker" @click="selectMarker"></l-marker> -->

        <l-marker
          :lat-lng="p.marker"
          v-for="(p, i, k) in points"
          :key="k"
          @click="selectMarker(p.point)"
        ></l-marker>
      </l-map>
    </div>

    <div class="selected" v-if="selected != undefined">
      <span>{{ selected.name }}</span> <br />
      <span>{{ selected.type }}</span> <br />
      <span>{{ selected.description }}</span> <br />
      <span>lat: {{ selected.lat }} lng: {{ selected.lng }}</span>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

import { LMap, LTileLayer, LMarker } from "vue2-leaflet";
import axios from "axios";
import * as V2L from "vue2-leaflet";

import L, { MarkerOptions } from "leaflet";
import { CONSTS } from "@/models/consts";
import { SkatePointModel } from "@/models/skate-point-model";
import { PairedPointModel } from "@/models/paired-point-model";

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

  data() {
    return {
      zoom: 13,
      center: L.latLng(47.41322, -1.219482),
      url: "http://{s}.tile.osm.org/{z}/{x}/{y}.png",
      attribution:
        '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors',
      // marker: L.latLng(47.41322, -1.219482),
      points: [] as PairedPointModel[],
      selected: undefined as SkatePointModel | undefined,
    };
  },

  created: async function () {
    // const container = this.$refs.map as HTMLElement;
    // container.appendChild(map.show());
    const res = await axios.get(`${CONSTS.ENDPOINT}/skate/getpoints`);

    const points: SkatePointModel[] = res.data as SkatePointModel[];
    this.points = points.map((p) => {
      return {
        marker: L.latLng(p.lat, p.lng),
        point: p,
      } as PairedPointModel;
    });
  },

  methods: {
    selectMarker: function (m: SkatePointModel) {
      console.log(m);
      this.selected = m;
    },
  },
});
</script>

<style lang="scss" scoped>
@import "~leaflet/dist/leaflet.css";

.map {
  width: 100%;
  height: 420px;
}
</style>