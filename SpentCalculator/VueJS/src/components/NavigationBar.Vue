<template>
  <header class="nav">
    <div class="container">
      <div class="row">
        <div class="brand">
          <a href="#" class="">{{ $t('app.title') }}</a>
        </div>
        <nav class="right-float">
          <a asp-controller="Home" asp-action="Index" class="btn-pill">{{ $t('navigation.home') }}</a>
          <a asp-controller="Spent" asp-action="Index" class="btn-pill">{{ $t('navigation.spents') }}</a>
          <a href="#" class="btn-pill">{{ $t('navigation.about') }}</a>
          <a href="#" class="btn btn-pill btn-primary-outline">{{ $t('navigation.admin') }}</a>
        </nav>
      </div>
    </div>
  </header>
</template>
