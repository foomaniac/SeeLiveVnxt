<template>
  <section class="hero">
    <div class="hero-body">
      <div class="container">
        <h1 class="title">Welcome to SeeLive!</h1>
        <h2>Find out what's going on in your area, tonight...</h2>

        <div class="field has-addons">
          <p class="control">
            <input
              class="input is-primary"
              type="text"
              placeholder="Enter Artist, City or Postcode..."
            />
          </p>
          <p class="control">
            <button class="button">
              Search
            </button>
          </p>
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
