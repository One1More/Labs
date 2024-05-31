plugins {
    id("java")
    kotlin("jvm")
}

group = "org.example"
version = "1.0-SNAPSHOT"

repositories {
    mavenCentral()
}

dependencies {
    testImplementation("org.junit.jupiter:junit-jupiter")
    testImplementation("junit:junit:4.13.2")
    testImplementation("org.mockito:mockito-core:4.11.0")
    testImplementation("org.springframework.boot:spring-boot-starter-test:3.2.4")
    testImplementation("com.h2database:h2:2.1.212")
    testImplementation(project(":cats-apiGateway"))
    testImplementation(project(":cats-apiGateway:kafka"))
    testImplementation(project(":cats-CatsMicroservice:client"))
    implementation(kotlin("stdlib-jdk8"))
    implementation("org.springframework:spring-context:6.1.3")
    implementation("org.springframework.kafka:spring-kafka:3.1.4")
    implementation("org.springframework.boot:spring-boot-starter-web:3.2.4")
    implementation("org.springframework.boot:spring-boot-starter-data-jpa:3.2.4")
    implementation("org.springframework.boot:spring-boot-starter-security:3.2.4")
    implementation("org.springframework.boot:spring-boot-starter-webflux:3.2.4")
    implementation("io.jsonwebtoken:jjwt:0.12.5")
    implementation("org.springframework.cloud:spring-cloud-gateway:4.1.3")
    implementation(project(":banks-core"))
    implementation(project(":banks-presentation"))
    implementation(project(":cats-apiGateway"))
    implementation(project(":cats-CatsMicroservice"))
    implementation(project(":cats-OwnersMicroservice"))
    compileOnly("org.projectlombok:lombok:1.18.32")
    annotationProcessor("org.projectlombok:lombok:1.18.32")
}

tasks.test {
    useJUnitPlatform()
    useJUnit()
}

kotlin {
    jvmToolchain(21)
}