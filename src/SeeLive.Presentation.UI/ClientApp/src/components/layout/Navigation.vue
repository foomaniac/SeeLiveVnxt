<template>
  <nav
    class="navbar is-dark level"
    role="navigation"
    aria-label="main navigation"
  >
    <div class="navbar-brand">
      <a class="navbar-item" href="/">
        <img src="../../assets/master_logo.png" alt="SeeLive" />
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
</template>

<script>
export default {
  name: "Navigation",
  props: {
    msg: String,
  },
};
</script>
