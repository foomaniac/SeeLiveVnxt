<template>
  <nav
    class="navbar is-dark"
    role="navigation"
    aria-label="main navigation"
  >
    <div class="navbar-brand">
      <a
        class="navbar-item"
        href="/"
      >
        <img
          src="../assets/master_logo.png"
          alt="SeeLive"
        />
      </a>

      <a
        role="button"
        class="navbar-burger burger"
        aria-label="menu"
        aria-expanded="false"
        data-target="navbarBasicExample"
      >
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
        <span aria-hidden="true"></span>
      </a>
    </div>

    <div class="navbar-menu">
      <div class="navbar-start">
        <a class="navbar-item">
          Home
        </a>
      </div>
    </div>
  </nav>
  <!-- <b-navbar>
    <template v-slot:brand>
      <b-navbar-item tag="router-link" :to="{ path: '/' }">
        <b-image
         
          alt="seeLive"
          :rounded="rounded"
        ></b-image>
      </b-navbar-item>
    </template>
  </b-navbar> -->
</template>

<script>
export default {
  name: "Navigation",
  props: {
    msg: String,
  },
};
</script>
