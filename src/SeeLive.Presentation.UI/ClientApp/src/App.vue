<template>
  <Navigation />
  <HomeHero />
</template>

<script>
import Navigation from "./components/Navigation.vue";
import HomeHero from "./components/HomeHero.vue";
export default {
  name: "App",
  components: {
    Navigation,
    HomeHero,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
