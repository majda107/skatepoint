<template>
  <div class="loader">
    <div class="loader-circle loader-circle-1"></div>
    <div class="loader-circle loader-circle-2"></div>
    <div class="loader-circle loader-circle-3"></div>
    <div class="loader-circle loader-circle-4"></div>
    <div class="loader-circle loader-circle-5"></div>
    <div class="loader-circle loader-circle-6"></div>
    <div class="loader-circle loader-circle-7"></div>
    <div class="loader-circle loader-circle-8"></div>
    <div class="loader-circle loader-circle-9"></div>
    <div class="loader-circle loader-circle-10"></div>
    <div class="loader-circle loader-circle-11"></div>
    <div class="loader-circle loader-circle-12"></div>
  </div>
</template>

<script>
export default {
  name: "Loader",
};
</script>

<style lang="scss" scoped>
@import "../../styles/main.scss";

.loader {
  width: 40px;
  height: 40px;
  position: relative;
  margin: 0 auto;
  background-color: transparent;
  .loader-circle {
    width: 100%;
    height: 100%;
    position: absolute;
    left: 0;
    top: 0;
  }
  .loader-circle:before {
    content: "";
    display: block;
    margin: 0 auto;
    width: 6px;
    height: 6px;
    // background-color: $dark-muted-color;
    background-color: gray;
    border-radius: 100%;
    animation: circleFadeDelay 1.2s infinite ease-in-out both;
  }
}
.loader,
.loader-circle {
  &-1 {
    transform: rotate(30deg);
  }
  &-2 {
    transform: rotate(60deg);
    &:before {
      animation-delay: -1.1s;
    }
  }
  &-3 {
    transform: rotate(90deg);
    &:before {
      animation-delay: -1s;
    }
  }
  &-4 {
    transform: rotate(120deg);
    &:before {
      animation-delay: -0.9s;
    }
  }
  &-5 {
    transform: rotate(150deg);
    &:before {
      animation-delay: -0.8s;
    }
  }
  &-6 {
    transform: rotate(180deg);
    &:before {
      animation-delay: -0.7s;
    }
  }
  &-7 {
    transform: rotate(210deg);
    &:before {
      animation-delay: -0.6s;
    }
  }
  &-8 {
    transform: rotate(240deg);
    &:before {
      animation-delay: -0.5s;
    }
  }
  &-9 {
    transform: rotate(270deg);
    &:before {
      animation-delay: -0.4s;
    }
  }
  &-10 {
    transform: rotate(300deg);
    &:before {
      animation-delay: -0.3s;
    }
  }
  &-11 {
    transform: rotate(330deg);
    &:before {
      animation-delay: -0.2s;
    }
  }
  &-12 {
    transform: rotate(360deg);
    &:before {
      animation-delay: -0.1s;
    }
  }
}
@keyframes circleFadeDelay {
  0%,
  39%,
  100% {
    opacity: 0;
  }
  40% {
    opacity: 1;
  }
}
</style>
