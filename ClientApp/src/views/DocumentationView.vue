<template>
  <div class="main-wrapper">
    <div class="doc">
      <div class="doc-header">Hello World</div>
      <div class="doc-about">
        Let's start by testing our setup. Open up a command prompt and enter the
        following command:
      </div>
      <pre><code class="typescript">export default Vue.extend({});</code></pre>
      <pre class="doc-code">
curl https://api.github.com/zen
Keep it logically awesome.</pre
      >
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({});
</script>

<style lang="scss" scoped>
@import "../../styles/main.scss";
</style>