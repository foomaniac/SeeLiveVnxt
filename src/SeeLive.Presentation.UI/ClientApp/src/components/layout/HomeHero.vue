<template>
  <section class="hero">
    <div class="hero-body">
      <h1 class="title">
        Welcome to <span class="secondary-font-hlight">see</span
        ><span class="primary-font-hlight">Live!</span>
      </h1>
      <h2>Find out what's going on in your area, tonight...</h2>

      <div class="field has-addons is-grouped is-grouped-centered">
        <div class="control">
          <input
            id="event-search"
            class="input is-primary"
            type="text"
            placeholder="Enter Artist, City or Postcode..."
          />
        </div>
        <div class="control">
          <button class="button is-danger">
            Search
          </button>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  name: "HomeHero",
  props: {},
};
</script>

<style scoped>
#event-search {
  width: 300px;
}

h1 {
  font-weight: normal;
  font-size: 3.5em;
}

.hero {
  background-image: url("../../assets/hero_bg_2.png");
  color: white;
}
</style>
