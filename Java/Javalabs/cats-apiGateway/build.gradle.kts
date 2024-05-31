plugins {
    id("java")
}

group = "ru.gobunov"
version = "1.0-SNAPSHOT"

repositories {
    mavenCentral()
}

dependencies {
    testImplementation(platform("org.junit:junit-bom:5.10.0"))
    testImplementation("org.junit.jupiter:junit-jupiter")
    implementation("org.springframework:spring-context:6.1.3")
    implementation("org.springframework.kafka:spring-kafka:3.1.4")
    implementation("org.springframework.boot:spring-boot-starter-security:3.2.4")
    implementation("org.springframework.boot:spring-boot-starter-data-jpa:3.2.4")
    implementation("org.springframework.boot:spring-boot-starter-web:3.2.4")
    implementation("io.jsonwebtoken:jjwt:0.12.5")
    compileOnly("org.projectlombok:lombok:1.18.32")
    annotationProcessor("org.projectlombok:lombok:1.18.32")
    implementation(project(":cats-OwnersMicroservice:ownersModel"))
    implementation(project(":cats-CatsMicroservice:model"))
    implementation(project("security"))
    implementation(project("controller"))
    implementation(project("service"))
    implementation(project("kafkaMessages"))
}

tasks.test {
    useJUnitPlatform()
}