<script setup lang="ts">
function searchClick() {
  console.log('click')
}
</script>

<template>
  <form class="head-form">
    <h1>Poor Man's Scraper <img src="@/assets/logo.png" class="logo" /></h1>
    <q-input
      type="url"
      class="search-input"
      outlined
      placeholder="Enter url to scrape..."
    >
      <template v-slot:after>
        <button class="">
          <q-icon @click="searchClick" name="search" />
        </button> </template
    ></q-input>
  </form>
</template>

<style scoped>
.head-form {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  min-height: 30vh;
}

h1 {
  font-size: 50px;
  font-weight: 200;
  display: flex;
  align-items: center;
  line-height: 50px;
}

.logo {
  width: 5rem;
}

.search-input {
  width: 100%;
  max-width: 48rem;
  margin-top: 0.5rem;
}

.input-class {
  border-radius: 40px;
}

.search-input-standout {
  border: 2px solid black;
  background: white;
}

@media (min-width: 640px) {
  h1 {
    font-size: 75px;
  }

  .logo {
    width: 7.5rem;
  }
}
</style>
