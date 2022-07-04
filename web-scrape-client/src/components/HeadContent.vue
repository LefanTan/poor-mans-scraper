<script setup lang="ts">
import { ref } from 'vue'
import axiosInstance from './config/axios'

const scrapeUrl = ref(
  'https://www.amazon.ca/Fullmosa-Quick-Release-Watch-Stainless/dp/B07F27GJH7?ref_=ast_sto_dp&th=1&psc=1'
)

const scrapedJsonResult = ref(0)
const isLoading = ref(false)

function searchClick() {
  isLoading.value = true
  axiosInstance
    .post('/scrape?url=' + encodeURIComponent(scrapeUrl.value))
    .then((res) => {
      scrapedJsonResult.value = res.data
      isLoading.value = false
    })
    .catch((err) => {
      console.error(err)
      isLoading.value = false
    })
}
</script>

<template>
  <form class="head-form">
    <h1>Poor Man's Scraper <img src="@/assets/logo.png" class="logo" /></h1>
    <p>It's scrapin' time</p>
    <q-input
      v-model="scrapeUrl"
      type="url"
      name="searchUrl"
      class="search"
      input-class="search-input"
      outlined
      :loading="isLoading"
      placeholder="Enter url to scrape..."
    >
      <template v-slot:after>
        <button type="submit" class="submit-button">
          <q-icon @click="searchClick" name="search" />
        </button> </template
    ></q-input>
  </form>
  <pre
    class="code"
  ><code>{{ scrapedJsonResult === 0 ? "Scrape a url to display something!" : scrapedJsonResult }}</code></pre>
</template>

<style scoped lang="less">
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
  line-height: 55px;
}

.code {
  white-space: pre-wrap;
  border-radius: 15px;
  padding: 1rem;
  background-color: rgb(243, 243, 243);
}

.logo {
  width: 5rem;
}

.search {
  width: 100%;
  max-width: 48rem;
  margin-top: 0.5rem;
}

.submit-button {
  cursor: pointer;
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
