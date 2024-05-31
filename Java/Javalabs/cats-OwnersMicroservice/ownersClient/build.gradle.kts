plugins {
    id("java")
}

group = "ru.gorbunov"
version = "1.0-SNAPSHOT"

repositories {
    mavenCentral()
}

dependencies {
    testImplementation(platform("org.junit:junit-bom:5.10.0"))
    testImplementation("org.junit.jupiter:junit-jupiter")
    implementation("org.springframework.boot:spring-boot-starter-webflux:3.2.4")
    implementation("org.springframework.boot:spring-boot-starter-web:3.2.4")
    implementation(project(":cats-OwnersMicroservice:ownersModel"))
}

tasks.test {
    useJUnitPlatform()
}