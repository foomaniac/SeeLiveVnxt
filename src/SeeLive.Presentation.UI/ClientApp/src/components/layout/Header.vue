<template>
  <div class="level">
    <div class="level-left is-half">
      <img
        src="../../assets/master_logo.png"
        alt="SeeLive"
      />
    </div>
    <div class="level-right is-half">
      <button class="button is-primary">
        <span>Login</span>
        <span class="icon">
          <i
            title="Login"
            class="fas fa-user"
          ></i>
        </span>
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "Header",
  props: {},
};
</script>

<style>
.level {
  margin-bottom: 0 !important;
  padding-left: 10px;
  padding-right: 10px;
}
</style>
