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
    runtimeOnly("org.postgresql:postgresql:42.7.3")
    implementation("org.springframework:spring-context:6.1.3")
    implementation("org.springframework.boot:spring-boot-starter-data-jpa:3.1.2")
    implementation(project(":cats-CatsMicroservice:model"))
    compileOnly("org.projectlombok:lombok:1.18.32")
    annotationProcessor("org.projectlombok:lombok:1.18.32")
}

tasks.test {
    useJUnitPlatform()
}