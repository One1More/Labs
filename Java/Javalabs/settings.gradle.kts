pluginManagement {
    plugins {
        kotlin("jvm") version "1.9.22"
    }
}
plugins {
    id("org.gradle.toolchains.foojay-resolver-convention") version "0.5.0"
}
rootProject.name = "Lab1"
include("banks-core")
include("banks-presentation")
include("cats-controller")
include("cats-service")
include("cats-dal")
