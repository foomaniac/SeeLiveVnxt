<template>
  <div id="main-app">
    <div id="header">
      <Header />
      <Navigation />
    </div>
    <div id="body">
      <HomeHero />
    </div>
  </div>
</template>

<script>
import Header from "./components/layout/Header.vue";
import Navigation from "./components/layout/Navigation.vue";
import HomeHero from "./components/layout/HomeHero.vue";
export default {
  name: "App",
  components: {
    Header,
    Navigation,
    HomeHero,
  },
};
</script>

<style>
html {
  height: 100%;
}

body {
  background-color: #f7f7f7;
  min-height: 100%;
}

.container {
  background-color: white;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
}

.primary-font-hlight {
  color: #ff006b;
}

.secondary-font-hlight {
  color: #ffdb00;
}
</style>
