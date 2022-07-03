<script setup lang="ts">
import HeadContent from '@/components/HeadContent.vue'
</script>

<template>
  <div class="wrapper">
    <HeadContent />
  </div>
</template>

<style>
@import '@/assets/base.css';
.wrapper {
  margin-left: 1rem;
  margin-right: 1rem;
}

@media (min-width: 640px) {
  .wrapper {
    margin-left: 3rem;
    margin-right: 3rem;
  }
}
</style>
